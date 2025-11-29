
class JuiceMaker
  JUICE_USED_PER_MINUTE = 5
  
  def self.debug_light_on?()
    true
  end

  def initialize(fluid : Int32)
    @running = false
    @fluid = fluid
  end

  def start()
    @running = true
  end

  def running?()
    @running
  end

  def add_fluid(amount : Int32)
    @fluid += amount
  end

  def stop(minutes_running : Int32)
    @running = false
    @fluid -= (minutes_running * JUICE_USED_PER_MINUTE)
  end
end
